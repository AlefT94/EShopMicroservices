using Marten.Schema;

namespace Catalog.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        //Maten UPSERT
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }
    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Headphones",
                Category = new List<string> { "Electronics", "Audio" },
                Description = "Noise-cancelling wireless headphones with superior sound quality.",
                ImageFile = "wireless_headphones.png",
                Price = 199.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "4K TV",
                Category = new List<string> { "Electronics", "Home Entertainment" },
                Description = "A 65-inch 4K TV with vibrant colors and deep blacks.",
                ImageFile = "4k_tv.png",
                Price = 1199.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Console",
                Category = new List<string> { "Electronics", "Gaming" },
                Description = "A next-gen gaming console with immersive graphics and fast load times.",
                ImageFile = "gaming_console.png",
                Price = 499.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartwatch",
                Category = new List<string> { "Electronics", "Wearables" },
                Description = "A sleek smartwatch with fitness tracking and notifications.",
                ImageFile = "smartwatch.png",
                Price = 149.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Bluetooth Speaker",
                Category = new List<string> { "Electronics", "Audio" },
                Description = "A portable Bluetooth speaker with rich sound and deep bass.",
                ImageFile = "bluetooth_speaker.png",
                Price = 99.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Digital Camera",
                Category = new List<string> { "Electronics", "Photography" },
                Description = "A compact digital camera with high resolution and optical zoom.",
                ImageFile = "digital_camera.png",
                Price = 299.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                Category = new List<string> { "Electronics", "Mobile" },
                Description = "A versatile tablet with a vibrant display and powerful processor.",
                ImageFile = "tablet.png",
                Price = 349.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smart Thermostat",
                Category = new List<string> { "Electronics", "Home Automation" },
                Description = "A smart thermostat that helps you save energy and stay comfortable.",
                ImageFile = "smart_thermostat.png",
                Price = 199.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Electric Toothbrush",
                Category = new List<string> { "Personal Care", "Health" },
                Description = "An electric toothbrush with multiple cleaning modes and a long battery life.",
                ImageFile = "electric_toothbrush.png",
                Price = 49.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fitness Tracker",
                Category = new List<string> { "Electronics", "Wearables" },
                Description = "A fitness tracker with heart rate monitoring and sleep tracking.",
                ImageFile = "fitness_tracker.png",
                Price = 79.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "E-book Reader",
                Category = new List<string> { "Electronics", "Mobile" },
                Description = "An e-book reader with a high-resolution display and long battery life.",
                ImageFile = "ebook_reader.png",
                Price = 129.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Robot Vacuum",
                Category = new List<string> { "Home Appliances", "Cleaning" },
                Description = "A robot vacuum that intelligently navigates and cleans your home.",
                ImageFile = "robot_vacuum.png",
                Price = 249.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Purifier",
                Category = new List<string> { "Home Appliances", "Health" },
                Description = "An air purifier with HEPA filter to keep your indoor air clean.",
                ImageFile = "air_purifier.png",
                Price = 149.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smart Lock",
                Category = new List<string> { "Electronics", "Home Security" },
                Description = "A smart lock that allows you to control access to your home remotely.",
                ImageFile = "smart_lock.png",
                Price = 179.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Drone",
                Category = new List<string> { "Electronics", "Photography" },
                Description = "A drone with a high-definition camera and stable flight capabilities.",
                ImageFile = "drone.png",
                Price = 399.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "VR Headset",
                Category = new List<string> { "Electronics", "Gaming" },
                Description = "A VR headset that offers an immersive virtual reality experience.",
                ImageFile = "vr_headset.png",
                Price = 299.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Instant Pot",
                Category = new List<string> { "Home Appliances", "Kitchen" },
                Description = "A versatile instant pot for quick and easy meal preparation.",
                ImageFile = "instant_pot.png",
                Price = 99.99M
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Espresso Machine",
                Category = new List<string> { "Home Appliances", "Kitchen" },
                Description = "An espresso machine that makes rich and flavorful coffee.",
                ImageFile = "espresso_machine.png",
                Price = 299.99M
            }

        };
    }
}