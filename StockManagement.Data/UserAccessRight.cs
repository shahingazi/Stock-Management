using System;

namespace StockManagement.Data
{
    public class UserAccessRight
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public AccessRight Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool DefaultCompany { get; set; }
    }

    public enum AccessRight
    {
        Admin=1,
        Contributor
    }

}
