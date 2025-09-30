using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PovarCRM.Documents
{
    internal class OrderPDFComposer : IDocument
    {
        private OrderCheck OrderCheck { get; }
        private List<ItemView> ItemViews { get; }

        public OrderPDFComposer(OrderCheck order, List<ItemView> views)
        {
            OrderCheck = order;
            ItemViews = views;
        }

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(30);

                    // --- Заголовок ---
                    page.Header().Column(column =>
                    {
                        column.Item().Text(BuildHeaderText())
                            .FontSize(18)
                            .Bold()
                            .FontColor(Colors.Blue.Darken2)
                            .AlignCenter();

                        column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                    });

                    // --- Таблица с позициями ---
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Состав заказа").FontSize(16).Bold();

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Название
                                columns.RelativeColumn(1); // Кол-во
                                columns.RelativeColumn(2); // Цена
                            });

                            // Заголовки таблицы
                            table.Header(header =>
                            {
                                header.Cell().Text("Позиция").Bold();
                                header.Cell().Text("Кол-во").Bold();
                                header.Cell().Text("Цена").Bold();
                            });

                            // Данные
                            foreach (var item in ItemViews)
                            {
                                table.Cell().Text(item.DishNaming);
                                table.Cell().Text(item.DishCount.ToString());
                                table.Cell().Text($"{item.ItemCost.Value:C}");
                            }

                            // Итого
                            table.Footer(footer =>
                            {
                                footer.Cell().ColumnSpan(2).Text("Итого:").Bold();
                                footer.Cell().Text($"{OrderCheck.Total:C}").Bold();
                            });
                        });
                    });

                    // --- Нижний колонтитул ---
                    page.Footer().AlignCenter().Text($"Сформирован: {OrderCheck.OrderTime:dd.MM.yyyy HH:mm}");
                });
        }

        private string BuildHeaderText()
        {
            string clientPart = string.IsNullOrWhiteSpace(OrderCheck.ClientName) ? "" : $" ({OrderCheck.ClientName})";
            string datePart = OrderCheck.OrderTime != default ? $" - {OrderCheck.OrderTime:HH:mm}" : "";
            return $"Чек заказа #{OrderCheck.Id}{clientPart}{datePart}";
        }
    }
}
