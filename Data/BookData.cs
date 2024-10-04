using SimplyBooks.Models;

namespace SimplyBooks.Data
{
    public class BookData
    {
        public static List<Book> Books = new()
        {
            new() {
                Id = 1,
                AuthorId = 2,
                Image = "https://images-na.ssl-images-amazon.com/images/I/91+NBrXG-PL.jpg",
                Price = 24.99m,
                Description = "",
                Sale = false,
                Title = "A Promised Land",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 2,
                AuthorId = 1,
                Image = "https://images-na.ssl-images-amazon.com/images/I/A1agLFsWkOL.jpg",
                Price = 12.99m,
                Description = "",
                Sale = true,
                Title = "Children of Blood and Bone",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 3,
                AuthorId = 3,
                Image = "https://images-na.ssl-images-amazon.com/images/I/51529Lfc2ML.jpg",
                Price = 30.00m,
                Description = "",
                Sale = false,
                Title = "A People's History of the United States of America",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 4,
                AuthorId = 4,
                Image = "https://images-na.ssl-images-amazon.com/images/I/81rRRmZZvZL.jpg",
                Price = 15.89m,
                Description = "",
                Sale = false,
                Title = "Concrete Rose",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 5,
                AuthorId = 5,
                Image = "https://images-na.ssl-images-amazon.com/images/I/A1Cu4ywUeyL.jpg",
                Price = 25.00m,
                Description = "",
                Sale = true,
                Title = "The Underground Railroad",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 6,
                AuthorId = 6,
                Image = "https://res.cloudinary.com/bloomsbury-atlas/image/upload/w_360,c_scale/jackets/9781526622402.jpg",
                Price = 12.99m,
                Description = "",
                Sale = true,
                Title = "Hood Feminism",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 7,
                AuthorId = 7,
                Image = "https://images-na.ssl-images-amazon.com/images/I/81Uf1dTjfQL.jpg",
                Price = 15.00m,
                Description = "",
                Sale = false,
                Title = "A Blade So Black",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 8,
                AuthorId = 7,
                Image = "https://m.media-amazon.com/images/I/51BZdlchEsL.jpg",
                Price = 14.99m,
                Description = "",
                Sale = false,
                Title = "A Dream So Dark",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            },
            new() {
                Id = 9,
                AuthorId = 8,
                Image = "https://images-na.ssl-images-amazon.com/images/I/61GSqXVhhKL.jpg",
                Price = 12.00m,
                Description = "",
                Sale = false,
                Title = "The Fire Next Time",
                Uid = "M66qijp8sxf8LqRKRKxCZkKNMgI3"
            }
        };
    }
}