using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitMvvmDemo.Core.Models;

namespace CommunityToolkitMvvmDemo.Core.ViewModels.CommunityToolkit;

public partial class SampleViewModel : ObservableObject
{
    #region NewMemberFirstName
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NewMemberFullName))]
    [NotifyCanExecuteChangedFor(nameof(RegisterMemberCommand))]
    private string _newMemberFirstName = string.Empty;
    #endregion

    #region NewMemberMiddleName
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NewMemberFullName))]
    [NotifyCanExecuteChangedFor(nameof(RegisterMemberCommand))]
    private string _newMemberMiddleName = string.Empty;
    #endregion

    #region NewMemberLastName
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NewMemberFullName))]
    [NotifyCanExecuteChangedFor(nameof(RegisterMemberCommand))]
    private string _newMemberLastName = string.Empty;
    #endregion

    #region NewMemberFullName
    public string NewMemberFullName => MemberViewModel.CreateFullName(NewMemberFirstName, NewMemberMiddleName, NewMemberLastName);
    #endregion

    #region Members
    [ObservableProperty]
    private System.Collections.ObjectModel.ObservableCollection<MemberViewModel> _members = [];
    #endregion

    #region SelectedMember
    [ObservableProperty]
    private MemberViewModel? _selectedMember;
    #endregion

    #region RegisterMemberCommand

    [RelayCommand(CanExecute = nameof(CanRegisterMember))]
    private void RegisterMember()
    {
        var newMember = new Member(NewMemberFirstName, NewMemberMiddleName, NewMemberLastName);
        var newMemberViewModel = new MemberViewModel(newMember);

        Members.Add(newMemberViewModel);

        NewMemberFirstName = string.Empty;
        NewMemberMiddleName = string.Empty;
        NewMemberLastName = string.Empty;

        RemoveMemberCommand.NotifyCanExecuteChanged();
    }

    private bool CanRegisterMember()
    {
        if (string.IsNullOrWhiteSpace(NewMemberFirstName) is false &&
            string.IsNullOrWhiteSpace(NewMemberLastName) is false)
        {
            return true;
        }

        return false;
    }
    #endregion

    #region RemoveMemberCommand
    [RelayCommand(CanExecute = nameof(CanRemoveMembers))]
    private void RemoveMember(MemberViewModel? member)
    {
        if (member is null)
        {
            return;
        }

        Members.Remove(member);

        SelectedMember = null;
        RemoveMemberCommand.NotifyCanExecuteChanged();
    }

    private bool CanRemoveMembers()
    {
        return Members.Count > 0;
    }
    #endregion
}
