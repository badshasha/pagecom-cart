namespace pagecom.cart.data.databaseConfiguration;

public  class DbInfo
{
    public static string? SA;
   
    public static string? RABBIT { get; set; } = null;
    public static string? RABBIT_PORT;
    public static string? RABBIT_VIRRUAL_HOST;
    public static string? HOST { get; set; } = null;
    public static string? PORT { get; set; } = null;
    public static string? DATABASE { get; set; } = null;
    public static string? USER { get; set; } = null;
    public static string? PASSWORD { get; set; } = null;
    
    // check azure environment 
    public static bool AZURE_ENVIRONMENT { get; set; }
}