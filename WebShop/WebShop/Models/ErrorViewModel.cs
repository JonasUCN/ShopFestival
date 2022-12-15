namespace WebShop.Models
{
    /// <summary>
    /// Represents a view model for displaying errors.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request ID should be displayed.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

