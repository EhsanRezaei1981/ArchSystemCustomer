using System.ComponentModel.DataAnnotations;

namespace ArchSystem.Dto.Models
{
    public abstract class Customer
    {
        public interface IIdentity
        {
            int CustomerId { get; set; }
        }

        public interface IBaseDto
        {
            [StringLength(50)]
            public string? Name { get; set; }
            [StringLength(50)]
            public string? Surname { get; set; }
            public string IDNumber { get; set; }
            [StringLength(128)]
            public string? Email { get; set; }
            public long? Tel { get; set; }
            public string? Country { get; set; }
        }
        public class BaseDto
        {
            [StringLength(50)]
            public string? Name { get; set; }
            [StringLength(50)]
            public string? Surname { get; set; }
            public string? IDNumber { get; set; }
            [StringLength(128)]
            public string? Email { get; set; }
            public long? Tel { get; set; }
            public string? Country { get; set; }
        }

        public abstract class Create {
            public class InputDto : BaseDto{}
            public class OutputDto:Models.OutputDto { 
                
            }
            
        }

        public abstract class Update
        {
            public class InputDto : BaseDto, IIdentity
            {
                [Required]
                public int CustomerId { get; set; }
                public string? LastUpdateDateTime { get; set; }
            }
            public class OutputDto : Models.OutputDto
            {

            }

        }

        public abstract class Delete
        {
            public class InputDto : IIdentity
            {
                [Required]
                public int CustomerId { get; set; }
                public string? LastUpdateDateTime { get; set; }
            }
            public class OutputDto : Models.OutputDto
            {

            }

        }

        public abstract class Retrieve
        {
            public class BaseOutputDto : BaseDto, IIdentity
            {
                public int CustomerId { get; set; }
                public string CreationDateTime{ get; set; }
                public string LastUpdateDateTime { get; set; }
            }
            public class Filter {
                public string? Name { get; set; }
                public string? Surname { get; set; }
                public string? IDNumber { get; set; }
                public string? Email { get; set; }
                public long? Tel { get; set; }
                public string? Country { get; set; }
                public Pagination Pagination { get; set; }
            }
            public class InputDto {
                public Filter Filter { get; set; }
            }
            public class OutputDto : Models.OutputListDto<BaseOutputDto>
            {

            }

            public abstract class ExportToXml {
                public class BaseOutputDto {
                    public string Filename { get; set; }
                }
                public class OutputDto : Models.OutputDto<BaseOutputDto>
                {

                }
            }
        }        
    }
}
