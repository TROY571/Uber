package models;

public class Costumer
{
    private int id;
    private String username;
    private String password;
    private String birthday;
    private String firstname;
    private String secondname;
    private String sex;
    private boolean isLogged;

    public Costumer(String username, String password)
    {
        this.username = username;
        this.password = password;
    }

    public Costumer(String username, String password, String birthday, String firstname, String secondname, String sex)
    {
        this.username = username;
        this.password = password;
        this.birthday = birthday;
        this.firstname = firstname;
        this.secondname = secondname;
        this.sex = sex;
    }

    public Costumer(int id,String username, String password, String birthday, String firstName, String secondName, String sex)
    {
        this.id = id;
        this.username = username;
        this.password = password;
        this.birthday = birthday;
        this.firstname = firstname;
        this.secondname = secondname;
        this.sex = sex;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setUsername(String username)
    {
        this.username = username;
    }

    public void setPassword(String password)
    {
        this.password = password;
    }

    public void setBirthday(String birthday)
    {
        this.birthday = birthday;
    }

    public void setFirstName(String firstName)
    {
        this.firstname = firstname;
    }

    public void setSecondName(String secondName)
    {
        this.secondname = secondname;
    }

    public int getId()
    {
        return id;
    }

    public String getUsername()
    {
        return username;
    }

    public String getPassword()
    {
        return password;
    }

    public String getBirthday()
    {
        return birthday;
    }

    public String getFirstName()
    {
        return firstname;
    }

    public String getSecondName()
    {
        return secondname;
    }

    public String toString()
    {

            return username + id + password + birthday + firstname + secondname + sex;

    }
}