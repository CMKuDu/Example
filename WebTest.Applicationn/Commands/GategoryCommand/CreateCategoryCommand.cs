using WebTest.Applicationn.DTOs;
using WebTest.Applicationn.ICommand;

namespace WebTest.Applicationn.Commands.GategoryCommand
{
    public class CreateCategoryCommand : ICommand<string>
    {
        public CategoryDTO CategoryDTO { get;}
        public CreateCategoryCommand(CategoryDTO categoryDTO)
        {
            CategoryDTO = categoryDTO;
        }
    }
}
