using CommunityToolkitMvvmDemo.Core.Models;
using CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate.Commands;

namespace CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate;

public class SampleViewModel : System.ComponentModel.INotifyPropertyChanged
{
    #region PropertyChanged
    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region NewMemberFirstName
    private string _newMemberFirstName = string.Empty;

    public string NewMemberFirstName
    {
        get => _newMemberFirstName;
        set
        {
            if (_newMemberFirstName != value)
            {
                _newMemberFirstName = value;
                OnPropertyChanged(nameof(NewMemberFirstName));
                OnPropertyChanged(nameof(NewMemberFullName));
                RegisterMemberCommand.NotifyCanExecuteChanged();
            }
        }
    }
    #endregion

    #region NewMemberMiddleName
    private string _newMemberMiddleName = string.Empty;

    public string NewMemberMiddleName
    {
        get => _newMemberMiddleName;
        set
        {
            if (_newMemberMiddleName != value)
            {
                _newMemberMiddleName = value;
                OnPropertyChanged(nameof(NewMemberMiddleName));
                OnPropertyChanged(nameof(NewMemberFullName));
                RegisterMemberCommand.NotifyCanExecuteChanged();
            }
        }
    }
    #endregion

    #region NewMemberLastName
    private string _newMemberLastName = string.Empty;

    public string NewMemberLastName
    {
        get => _newMemberLastName;
        set
        {
            if (_newMemberLastName != value)
            {
                _newMemberLastName = value;
                OnPropertyChanged(nameof(NewMemberLastName));
                OnPropertyChanged(nameof(NewMemberFullName));
                RegisterMemberCommand.NotifyCanExecuteChanged();
            }
        }
    }
    #endregion

    #region NewMemberFullName
    public string NewMemberFullName => MemberViewModel.CreateFullName(NewMemberFirstName, NewMemberMiddleName, NewMemberLastName);
    #endregion

    #region Members
    private System.Collections.ObjectModel.ObservableCollection<MemberViewModel> _members = [];

    public System.Collections.ObjectModel.ObservableCollection<MemberViewModel> Members
    {
        get => _members;
        set
        {
            if (_members != value)
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }
    }
    #endregion

    #region SelectedMember
    private MemberViewModel? _selectedMember;

    public MemberViewModel? SelectedMember
    {
        get => _selectedMember;
        set
        {
            if (_selectedMember != value)
            {
                _selectedMember = value;
                OnPropertyChanged(nameof(SelectedMember));
            }
        }
    }
    #endregion

    #region RegisterMemberCommand
    public IRelayCommand RegisterMemberCommand { get; set; }

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
    public IRelayCommand<MemberViewModel> RemoveMemberCommand { get; set; }

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

    #region Constructor
    public SampleViewModel()
    {
        RegisterMemberCommand = new RelayCommand(
            execute: new Action(RegisterMember),
            canExecute: CanRegisterMember);

        RemoveMemberCommand = new RelayCommand<MemberViewModel>(
            execute: new Action<MemberViewModel?>(RemoveMember),
            canExecute: _ => CanRemoveMembers());
    }
    #endregion
}
