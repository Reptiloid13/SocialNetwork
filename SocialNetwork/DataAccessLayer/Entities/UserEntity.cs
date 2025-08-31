using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccessLayer.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string photo { get; set; }
    public string favorite_movie { get; set; }
    public string favorite_book { get; set; }

}
