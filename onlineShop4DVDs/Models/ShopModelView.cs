namespace onlineShop4DVDs.Models
{
    public class ShopModelView
    {
        public IEnumerable<Album> ShopAlbum{ get; set; }

        public IEnumerable<Artist> ShopArtist { get; set; }

        public IEnumerable<Category> ShopCategory { get; set; }

        public IEnumerable<Feedback> ShopFeedback { get; set; }

        public IEnumerable<Game> ShopGame { get; set; }

        public IEnumerable<Movie> ShopMovie { get; set; }

        public IEnumerable<Producer> ShopProducer { get; set; }

        public IEnumerable<Product> ShopProduct { get; set; }

        public IEnumerable<Review> ShopReview { get; set; }

        public IEnumerable<Song> ShopSong { get; set; }

        public IEnumerable<Supplier> ShopSupplier { get; set; }

        public UserCred UserCred { get; set; }

    }
}
