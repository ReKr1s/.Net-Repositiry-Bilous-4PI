using System;
using System.Collections.Generic;
using System.Linq;
using Bilous.TaskPlanner.Domain.Models;

namespace Bilous.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            var itemsAsList = items.ToList();
            itemsAsList.Sort(CompareWorkItems);
            return itemsAsList.ToArray();
        }

        private static int CompareWorkItems(WorkItem firstItem, WorkItem secondItem)
        {
            // 1. За пріоритетом — за спаданням
            int priorityCompare = secondItem.Priority.CompareTo(firstItem.Priority);
            if (priorityCompare != 0)
                return priorityCompare;

            // 2. За датою — за зростанням
            int dateCompare = firstItem.DueDate.CompareTo(secondItem.DueDate);
            if (dateCompare != 0)
                return dateCompare;

            // 3. За назвою — в алфавітному порядку
            return string.Compare(firstItem.Title, secondItem.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
