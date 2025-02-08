class ContactClass:
    def __init__(self, firstName, lastName, street, city, state, zipcode, phoneNumber, email):
        self.firstName = firstName;
        self.lastName = lastName;
        self.street = street;
        self.city = city;
        self.state = state;
        self.zipcode = zipcode;
        self.phoneNumber = phoneNumber;
        self.email = email;

    def __str__(self):
        return f"{self.lastName}, {self.firstName}\n{self.street}\n{self.city}, {self.state} {self.zipcode}\n{self.phoneNumber}\n{self.email}"