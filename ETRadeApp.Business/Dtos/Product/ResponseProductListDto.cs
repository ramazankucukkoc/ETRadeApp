﻿using ETRadeApp.Business.Dtos.Category;

namespace ETRadeApp.Business.Dtos.Product
{
    public class ResponseProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public ResponseCategoryListDto Category { get; set; }
    }
}
