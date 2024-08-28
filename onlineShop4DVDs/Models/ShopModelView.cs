namespace onlineShop4DVDs.Models
{
    public class ShopModelView
    {
        public Album ShopAlbum{ get; set; }

        public List<Artist> ShopArtist { get; set; }

        public List<Category> ShopCategory { get; set; }

        public List<Feedback> ShopFeedback { get; set; }

        public List<Game> ShopGame { get; set; }

        public List<Movie> ShopMovie { get; set; }

        public List<Producer> ShopProducer { get; set; }

        public List<Product> ShopProduct { get; set; }

        public List<Review> ShopReview { get; set; }

        public List<Song> ShopSong { get; set; }

        public List<Supplier> ShopSupplier { get; set; }

        public UserCred UserCred { get; set; }

    }
}
