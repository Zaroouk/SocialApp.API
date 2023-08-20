using SocialApp.API.Models;

namespace SocialApp.API.Dtos;

public class FollowToAddDto
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}