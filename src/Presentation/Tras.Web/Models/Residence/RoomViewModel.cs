using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tras.Core.Domain.Residence;
using Tras.Web.Framework.Mapping;
using Tras.Web.Framework.ViewModelAttributes;

namespace Tras.Web.Models.Residence
{
    public class RoomViewModel : IMapFrom<Room>
    {
        [Render(ShowForEdit = false)]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Please select a mess")]
        [DisplayName("Mess")]
        public int MessId { get; set; }
        
        [DisplayName("Mess")]
        public string MessName { get; set; }

        [Required(ErrorMessage = "Please enter a room name")]
        [DataType (DataType.Text)]
        [DisplayName("Room Name")]
        [Display(Prompt="Room Name")]
        public string RoomName { get; set; }
    }
}