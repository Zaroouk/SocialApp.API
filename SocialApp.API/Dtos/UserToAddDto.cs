using SocialApp.API.Models;

namespace SocialApp.API.Dtos;

public class UserToAddDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public IEnumerable<Follow>? FollowerList { get; set; }
    public IEnumerable<Follow>? FollowingList { get; set; }
    public string PrivacySettings { get; set; } = string.Empty;
}