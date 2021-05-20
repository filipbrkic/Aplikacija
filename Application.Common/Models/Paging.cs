﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Paging : IPaging
    {
        public Paging(int? pageNumber, int? pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize ?? 5;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Skip
        {
            get
            {
                return (PageNumber - 1) * PageSize;
            }
            set { }
        }
        public int TotalItemsCount { get; set; }
    }
}
