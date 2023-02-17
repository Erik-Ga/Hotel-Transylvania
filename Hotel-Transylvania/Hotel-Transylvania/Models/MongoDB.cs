using MongoDB.Driver;

namespace Hotel_Transylvania.Models
{
    internal class MongoDB
    {
        public static async Task MongoDBSave()
        {
            // Detta är authentication information
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Erik:Pumpa123@cluster0.kh2vogk.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            
            // Detta är MongoDb-path till databasen
            var database = client.GetDatabase("TheHotelDb");

            // Detta är MongoDb-path till gästsamlingen
            var myGuestCollection = database.GetCollection<Models.Guest>("MyGuestCollection");

            // Skapar ny gäst
            Models.Guest guest1 = new() { Id = new Guid(), Name = "Test Person"};
            Task saveGuest = Models.MongoDB.SaveGuest(guest1, myGuestCollection);

            await saveGuest;

            // Lägger över alla gäster till en lista via metod från gästsamlingen i databasen
            Task<List<Guest>> getAllGuests = GetAllGuests(myGuestCollection);

            // Printar alla gäster i listan
            List<Guest> guests = await getAllGuests;
            foreach (Guest guest in guests)
            {
                Console.WriteLine(guest.Id + " " + guest.Name);
            }

        }

        public static async Task SaveGuest(Guest guest, IMongoCollection<Guest> guestCollection) // Lägger in gäst i databasen
        {
            await guestCollection.InsertOneAsync(guest);
            Console.WriteLine("Guest Saved!");
        }
        public static async Task<List<Guest>> GetAllGuests(IMongoCollection<Guest> guestCollection) // Hämtar alla gäster i databasen
        {
            var allGuests = await guestCollection.AsQueryable().ToListAsync();
            Console.WriteLine("Guests fetched!");
            return allGuests;
        }
    }
}
