using BusinessObject;
using DataAccess.Database;
using DataAccess.Repository;
using System.ComponentModel.DataAnnotations;

namespace MyStoreWinApp.Utility
{
    public sealed class SearchResponse<T> : DatabaseResponse<T> { }

    public abstract class SearchHelper<T> : IInputHelper<T> where T : class
    {
        public IRepository<T> repository { get; set; }
        public Func<T, bool> condition { get; set; }
        public abstract string Input { get; set; }
        public bool ValidateInput()
        {
            try
            {
                Validator.ValidateObject(this, new ValidationContext(this), true);
                return true;
            }
            catch (ValidationException)
            {
                return false;
            }
        }
        public abstract SearchResponse<IList<T>> Search();
    }

    public class SearchWithNumberInput<T> : SearchHelper<T> where T : class
    {
        [DataType("int")]
        [RegularExpression("[0-9]+")]
        public override string Input { get; set; } = "0";

        public override SearchResponse<IList<T>> Search()
        {
            bool isValid = ValidateInput();
            IList<T> response = null;
            if (isValid) response = Input == "0" ? repository.GetAll()
                                            : repository.GetListByCondition(condition);
            return new SearchResponse<IList<T>>
            {
                IsSuccess = isValid,
                Message = isValid ? string.Empty : "Input must be a number",
                Response = response
            };
        }
    }

    public class SearchById<T> : SearchWithNumberInput<T> where T : class { }
    public class SearchByPrice<T> : SearchWithNumberInput<T> where T : class { }
    public class SearchByUnitsInStock<T> : SearchWithNumberInput<T> where T : class { }

    public class SearchByName<T> : SearchHelper<T> where T : class
    {
        [Required]
        [RegularExpression("^([a-zA-Z]+[\\s]*)+$")]
        public override string Input { get; set; } = string.Empty;

        public override SearchResponse<IList<T>> Search()
        {
            bool isValid = ValidateInput();
            IList<T> response = null;
            if(string.IsNullOrEmpty(Input)) response = repository.GetAll();
            else response = isValid ? repository.GetListByCondition(condition) : null;
            return new SearchResponse<IList<T>>
            {
                IsSuccess = isValid || string.IsNullOrEmpty(Input),
                Message = isValid ? string.Empty : "Input must be a Name",
                Response = response
            };
        }
    }

    public sealed class SearchByEmail<T> : SearchByName<T> where T : Member
    {
    }  
}
