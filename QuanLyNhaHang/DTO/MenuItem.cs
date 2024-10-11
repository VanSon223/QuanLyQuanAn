using Newtonsoft.Json;

namespace QuanLyNhaHang.DTO
{
    public class MenuItem
    {
        // Constructor with parameters
        public MenuItem(int menuitemid, string name, decimal price, string category, string description)
        {
            this.MenuItemID = menuitemid;
            this.Name = name;
            this.Price = price;
            this.Category = category;        
            this.Description = description;  
            //this.Image = Image;
        }

        // Default constructor
        public MenuItem() { }

        [JsonProperty("menuItemId")]
        public int MenuItemID { get; set; }

        [JsonProperty("itemName")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }

        
        [JsonProperty("category")]
        public string Category { get; set; }

        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("image")]
        public byte[] Image { get; set; }
        
    }
}
