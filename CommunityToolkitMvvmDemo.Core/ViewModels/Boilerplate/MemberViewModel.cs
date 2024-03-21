using CommunityToolkitMvvmDemo.Core.Models;

namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate;

public class MemberViewModel(Member member) : System.ComponentModel.INotifyPropertyChanged
{
    private readonly Member _member = member;

    #region PropertyChanged
    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region FirstName
    public string FirstName
    {
        get => _member.FirstName;
        set
        {
            if (_member.FirstName != value)
            {
                _member.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
    #endregion

    #region MiddleName
    public string MiddleName
    {
        get => _member.MiddleName;
        set
        {
            if (_member.MiddleName != value)
            {
                _member.MiddleName = value;
                OnPropertyChanged(nameof(MiddleName));
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
    #endregion

    #region LastName
    public string LastName
    {
        get => _member.LastName;
        set
        {
            if (_member.LastName != value)
            {
                _member.LastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
    #endregion

    #region FullName
    public string FullName => CreateFullName(FirstName, MiddleName, LastName);
    #endregion

    public static string CreateFullName(params string[] names)
    {
        return string.Join(
            separator: " ",
            values: names.Where(name => string.IsNullOrWhiteSpace(name) is false));
    }

    public Member GetMember() => _member;
}
