using OnlineAuction.Debugging;

namespace OnlineAuction
{
    public class OnlineAuctionConsts
    {
        public const string LocalizationSourceName = "OnlineAuction";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "28637849229d4615b5d86e67ac3dfd3e";
    }
}
