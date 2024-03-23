using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkitMvvmDemo.Core.Models;

namespace CommunityToolkitMvvmDemo.Core.ViewModels.CommunityToolkit;

public partial class MemberViewModel(Member member) : ObservableObject
{
    private readonly Member _member = member;

    #region FirstName
    public string FirstName
    {
        get => _member.FirstName;
        set
        {
            SetProperty(_member.FirstName, value, _member, (member, firstName) => member.FirstName = firstName);
            OnPropertyChanged(nameof(FullName));
        }
    }
    #endregion

    #region MiddleName
    public string MiddleName
    {
        get => _member.MiddleName;
        set
        {
            SetProperty(_member.MiddleName, value, _member, (member, middleName) => member.MiddleName = middleName);
            OnPropertyChanged(nameof(FullName));
        }
    }
    #endregion

    #region LastName
    public string LastName
    {
        get => _member.LastName;
        set
        {
            SetProperty(_member.LastName, value, _member, (member, lastName) => member.LastName = lastName);
            OnPropertyChanged(nameof(FullName));
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
