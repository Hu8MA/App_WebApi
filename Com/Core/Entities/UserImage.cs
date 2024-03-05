using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Entities
{
    public class UserImage
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Imagepath { get; set; } = string.Empty;
        public required bool Is_visible { get; set; } = true;
        public int IdUser {  get; set; }
        [ForeignKey("IdUser")]
        public virtual UserInfo UserInfo { get; set; }
     }
}
