using SeleniumClient;

namespace Map
{
    public static class UIMap
    {
        public static WebLocator Input = WebLocator.Css("input[name='q']");

        //Navigation 
        public static WebLocator NavigationProfileLink = WebLocator.Css(".navigation > ul > li a[href='/']");
        public static WebLocator NavigationLoginLink = WebLocator.Css(".navigation > ul > li a[name='Cancel']");
        public static WebLocator NavigationLogoutLink = WebLocator.Css(".navigation > ul > li a[href='#']:not([name='Cancel'])");
        public static WebLocator NavigationAddMovieLink = WebLocator.Css(".navigation > ul > div li > a[href='/addMovie']");
        public static WebLocator OpenNavigationButton = WebLocator.Css("#main > span > button");

        // Login Fields
        public static WebLocator LoginUserName = WebLocator.Css(".navigation .nav-item input[type='text']");
        public static WebLocator LoginPassword = WebLocator.Css(".navigation .nav-item input[type='password']");
        public static WebLocator LoginButton = WebLocator.Css(".navigation .nav-item button[type='button']");

        //Admin specific
        public static WebLocator AdminNavigationMenu = WebLocator.Css(".navigation > ul > div");

        //Add Movie
        public static WebLocator AddMovieTitleField = WebLocator.Css(".row.form-group input[name='title']");
        public static WebLocator AddMovieDirectorField = WebLocator.Css(".row.form-group input[name='director']");
        public static WebLocator AddMovieDescriptionField = WebLocator.Css(".row.form-group textarea[name='description']");

        //Categories selector
        public static WebLocator AddMovieCategoriesField = WebLocator.Css(".row.form-group select[name='categories']");

        //CategoriesOption
        public static WebLocator AddMovieComedyOption = WebLocator.Css(".row.form-group option[value='Comedy']");
        public static WebLocator AddMovieDramaOption = WebLocator.Css(".row.form-group option[value='Drama']");
        public static WebLocator AddMovieThrillerOption = WebLocator.Css(".row.form-group option[value='Thriller']");
        public static WebLocator AddMovieURLField = WebLocator.Css(".row.form-group input[name='file']");

        //Rating
        public static WebLocator AddMovieRating1Field = WebLocator.Css(".row.form-group svg:nth-child(1)");
        public static WebLocator AddMovieRating2Field = WebLocator.Css(".row.form-group svg:nth-child(2)");
        public static WebLocator AddMovieRating3Field = WebLocator.Css(".row.form-group svg:nth-child(3)");
        public static WebLocator AddMovieRating4Field = WebLocator.Css(".row.form-group svg:nth-child(4)");
        public static WebLocator AddMovieRating5Field = WebLocator.Css(".row.form-group svg:nth-child(5)");
        public static WebLocator AddMovieRatingValid = WebLocator.Css(".row.form-group label[for='rating'] + div div.valid-feedback");

        //Buttons
        public static WebLocator AddMoviedSaveButton = WebLocator.Css(".row.form-group button.btn-success");
        public static WebLocator AddMoviedDiscardButton = WebLocator.Css(".row.form-group button.btn-danger");
    }
}
