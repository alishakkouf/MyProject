using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared.RequestDtos
{
    [Serializable]
    public class PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// Sorting field name
        /// </summary>
        public string SortingField { get; set; }

        /// <summary>
        /// Sorting direction: 1- Ascending (default), 2- Descending
        /// </summary>
        public SortingDirection? SortingDir { get; set; }

        /// <summary>
        /// The page index (starts with 1)
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "PositiveInteger")]
        public int? PageIndex { get; set; } = Constants.DefaultPageIndex;

        /// <summary>
        /// Count of items per page (10, 20, 30, 1000) 1000 means all items with no pagination
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "PositiveInteger")]
        public int? PageSize { get; set; } = Constants.DefaultPageSize;

        public bool IsPaginated() => PageSize < Constants.AllItemsPageSize;
    }
}
