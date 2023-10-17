using Xunit;

public class ProgramTest {    [Fact]
    public void Login_works_with_correct_credentials() {
        //Arrange
        Program program = new Program();
        
        //Act
        bool result = program.Login("admin", "admin");

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void Login_fails_with_incorrect_credentials() {
        //Arrange
        Program program = new Program();
        
        //Act
        bool result = program.Login("admin", "wrongpassword");

        //Assert
        Assert.False(result);
    }

    // One-switch test
    [Fact]
    public void Program_is_in_correct_state_at_launch() {
        //Arrange
        Program program = new Program();

        //Act

        //Assert
        Assert.False(program.LoggedIn);
    }

    [Fact]
    public void State_changes_when_logging_in() {
        //Arrange
        Program program = new Program();
        
        //Act
        program.Login("admin", "admin");
        
        //Assert
        Assert.True(program.LoggedIn);
    }

    [Fact]
    public void Do_stuff_can_run_when_logged_in() {
        //Arrange
        Program program = new Program();
        program.Login("admin", "admin");
        
        //Act
        bool result = program.DoStuff();
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void Do_stuff_cannot_run_when_not_logged_in() {
        //Arrange
        Program program = new Program();
        
        //Act
        bool result = program.DoStuff();
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void Logout_works() {
        //Arrange
        Program program = new Program();
        program.Login("admin", "admin");
        
        //Act
        program.Logout();
        
        //Assert
        Assert.False(program.LoggedIn);
    }

    //Two-switch test
    [Fact]
    public void State_changes_when_logging_out_and_back_in() {
        //Arrange
        Program program = new Program();
        
        //Act
        program.Login("admin", "admin");
        program.Logout();
        program.Login("admin", "admin");
        
        //Assert
        Assert.True(program.LoggedIn);
    }


}