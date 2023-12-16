namespace GetGetherIdentityServer.Data
{
    public class DbInitializer
    {
        public static  void Initialize (IdentityDBContext context) 
        { 
            context.Database.EnsureCreated ();
        }   
    }
}
