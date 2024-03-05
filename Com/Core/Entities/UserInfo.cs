using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Entities
{
    public  class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public required string Name { get; set; } = string.Empty;
         
        [RegularExpression(@"^\d{11}$")]
        public required string Phonenumber { get; set; }=string.Empty;

        [StringLength(16)]
        public required string Location { get; set; }=string.Empty;
        public required bool Is_visible { get; set; } = true;

        public DateTime TimeOfPublish { get; set; } = DateTime.UtcNow;

        public virtual UserImage? Images { get; set; }
        public virtual UserState? UserState { get; set; }
    }
}
