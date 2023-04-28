using Newtonsoft.Json;

namespace UseNewtonSoft
{
    class User
    {
        [JsonPropertyAttribute("id")]
        public int Id { get; set; }

        [JsonPropertyAttribute("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyAttribute("last_name")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyAttribute("email")]
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"User {{ {Id}| {FirstName} {LastName}| {Email} }}";
        }
    }
}
