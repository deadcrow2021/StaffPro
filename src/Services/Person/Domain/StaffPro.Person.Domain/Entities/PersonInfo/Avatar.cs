namespace StaffPro.Person.Domain.Entities.PersonInfo;

/// <summary>
/// URL аватара сущности Person
/// </summary>
public class Avatar
{
    /// <summary>
    /// URL аватара
    /// </summary>
    public string AvatarURL { get; private set; }

    /// <summary>
    /// Конструктор класса Avatar
    /// </summary>
    /// <param name="avatarURL"></param>
    public Avatar(string avatarURL)
    {
        AvatarURL = ValidateURL(avatarURL);
    }


    private static string ValidateURL(string avatarURL)
    {
        if ( Path.IsPathRooted(avatarURL) && (avatarURL.EndsWith(".png") || avatarURL.EndsWith(".jpg")) )
        {
            return avatarURL;
        }

        throw new ArgumentException("Avatar URL is not valid.");
    }

    /// <summary>
    /// Изменить URL аватара
    /// </summary>
    /// <param name="avatarURL"></param>
    public void ChangeAvatarURL(string avatarURL)
    {
        AvatarURL = ValidateURL(avatarURL);
    }

}
