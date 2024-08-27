namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// URL аватара сущности Person
/// </summary>
public class Avatar
{
    /// <summary>
    /// URL аватара
    /// </summary>
    public string AvatarURL { get; init; }

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
}
