namespace CleanArch.Domain.Constants
{
    public static class ValidationMessages
    {
        //Shared
        public const string Entity_Required_Id_Error = "Identifier number is required!";

        //Note
        public const string Note_Content_Length_Error = "Content length must be between 1 and 500 character!";
        public const string Note_Title_Length_Error = "Title length must be between 1 and 25 character!";

        //Tag
        public const string Tag_Description_Length_Error = "Content length must be between 1 and 20 character!";
        public const string Tag_Name_Length_Error = "Title length must be between 1 and 50 character!";
        public const string Note_IsFavorited_Error = "Favorite status must be true or false!";
    }
}
