using System.ComponentModel.DataAnnotations.Schema;

namespace SocialApp.API.Models;

public class Follow
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    [NotMapped]
    public User? Follower { get; set; }
    [NotMapped]
    public User? Following { get; set; }
}