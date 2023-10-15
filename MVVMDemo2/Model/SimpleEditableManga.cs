using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo2.Model
{
    class SimpleEditableManga : ValidatableBindableBase
    {
        //id : can use Guid - GloballyUniqueIdentifier 
        private string _id;
        [Required(ErrorMessage = "Id is required")]
        [RegularExpression(@"^M\d{2}$", ErrorMessage = "Id must be in the format M01")]
        public string Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private string _name;
        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Name cannot be longer than 40 characters")]
        public string Name
        {
            get => _name;
            set 
            {
                SetProperty(ref _name, value);
            }
        }
        private int _episode;
        [Required(ErrorMessage = "Episode is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Episode must be an integer")]
        public int Episode
        {
            get => _episode;
            set
            {
                SetProperty(ref _episode, value);
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                SetProperty(ref _description, value);
            }

        }
        private string _age;
        [Required(ErrorMessage = "Age is required")]
        [RegularExpression(@"^\d+\+$", ErrorMessage = "Age should be like '12+' ")]
        public string Age 
        {
            get => _age;
            set
            {
                SetProperty(ref _age, value);
            }
        }

    }
}
