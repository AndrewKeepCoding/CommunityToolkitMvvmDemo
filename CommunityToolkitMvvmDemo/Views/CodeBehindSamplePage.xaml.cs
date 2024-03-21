using CommunityToolkitMvvmDemo.Core.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace CommunityToolkitMvvmDemo.Views;

public sealed partial class CodeBehindSamplePage : Page
{
    public CodeBehindSamplePage()
    {
        this.InitializeComponent();
        this.RegisterMemberButton.IsEnabled = false;
        this.RemoveMemberButton.IsEnabled = false;
        this.MembersListView.ItemsSource = this.Members;
    }

    private ObservableCollection<Member> Members { get; } = [];

    private Member? SelectedMember { get; set; }

    public static string CreateFullName(params string[] names)
    {
        return string.Join(
            separator: " ",
            values: names.Where(name => string.IsNullOrWhiteSpace(name) is false));
    }

    private bool CanRegisterMember()
    {
        if (string.IsNullOrWhiteSpace(this.NewMemberFirstNameTextBox.Text) is false &&
            string.IsNullOrWhiteSpace(this.NewMemberLastNameTextBox.Text) is false)
        {
            return true;
        }

        return false;
    }

    private bool CanRemoveMembers()
    {
        return Members.Count > 0;
    }

    private void NewMemberTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.NewMemberFullNameTextBox.Text = CreateFullName(
            this.NewMemberFirstNameTextBox.Text,
            this.NewMemberMiddleNameTextBox.Text,
            this.NewMemberLastNameTextBox.Text);

        this.RegisterMemberButton.IsEnabled = this.CanRegisterMember();
    }

    private void RegisterMemberButton_Click(object sender, RoutedEventArgs e)
    {
        var newMember = new Member(
            this.NewMemberFirstNameTextBox.Text,
            this.NewMemberMiddleNameTextBox.Text,
            this.NewMemberLastNameTextBox.Text);

        Members.Add(newMember);

        this.NewMemberFirstNameTextBox.Text = string.Empty;
        this.NewMemberMiddleNameTextBox.Text = string.Empty;
        this.NewMemberLastNameTextBox.Text = string.Empty;

        this.RemoveMemberButton.IsEnabled = this.CanRemoveMembers();
    }

    private void RemoveMemberButton_Click(object sender, RoutedEventArgs e)
    {
        if (this.MembersListView.SelectedItem is not Member selectedMember)
        {
            return;
        }

        this.Members.Remove(selectedMember);
        this.RemoveMemberButton.IsEnabled = this.CanRemoveMembers();
    }

    private void MembersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            this.EdittingMemberFirstNameTextBox.TextChanged -= this.EdittingMemberTextBox_TextChanged;

            if (sender is not ListView listView ||
                listView.SelectedItem is not Member selectedMember)
            {
                SelectedMember = null;
                this.EdittingMemberFirstNameTextBox.Text = string.Empty;
                this.EdittingMemberMiddleNameTextBox.Text = string.Empty;
                this.EdittingMemberLastNameTextBox.Text = string.Empty;
                return;
            }

            SelectedMember = selectedMember;
            this.EdittingMemberFirstNameTextBox.Text = SelectedMember.FirstName;
            this.EdittingMemberMiddleNameTextBox.Text = SelectedMember.MiddleName;
            this.EdittingMemberLastNameTextBox.Text = SelectedMember.LastName;
        }
        finally
        {
            this.EdittingMemberFirstNameTextBox.TextChanged += this.EdittingMemberTextBox_TextChanged;
        }
    }

    private void EdittingMemberTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (SelectedMember is null)
        {
            return;
        }

        SelectedMember.FirstName = this.EdittingMemberFirstNameTextBox.Text;
        SelectedMember.MiddleName = this.EdittingMemberMiddleNameTextBox.Text;
        SelectedMember.LastName = this.EdittingMemberLastNameTextBox.Text;

        this.MembersListView.SelectionChanged -= this.MembersListView_SelectionChanged;

        this.MembersListView.ItemsSource = null;
        this.MembersListView.ItemsSource = this.Members;
        this.MembersListView.SelectedItem = SelectedMember;


        this.MembersListView.SelectionChanged += this.MembersListView_SelectionChanged;

        this.MembersListView.SelectedItem = SelectedMember;
    }
}
