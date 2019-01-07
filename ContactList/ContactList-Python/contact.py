import sys

people = []
contact = {}

def load():
    try:
        with open('contact.txt') as co:
            lines = co.readlines()
            i = 0
            for l in lines:
                b = l.split(" ")
                name = b[0]
                people.append(name)
                number = b[1]
                email = b[2]
                co = Contact(name, number, email)
                contact[name] = co
                print(co)
                i = i + 1
    except FileNotFoundError as e:
        print("No data file found, empty list")
    finally:
        pass

def add():
    print("Add Contact ========>")
    print("What is the contact name?")
    p = sys.stdin.readline().strip()
    if p == "" or p == " ":
        print("Contact name can not be empty.")
        add()
    elif people.__contains__(p):
        print("This contact is already exist")
        add()
    else:
        print("What is the tel number?")
        n = sys.stdin.readline().strip()
        print("What is the email address?");
        e = sys.stdin.readline().strip()
        co = Contact(p, n, e)
        people.append(p)
        contact[p] = co
        print("Add Contact suceed.")

def remove(p):
    if people.__contains__(p):
       print("Removing : " + p)
       people.remove(p)
       del contact[p]
    else:
        print("This contact does not exist.")

def update():
    print("Update Contact ========>")
    print("Which one do you want to update?");
    print(people)
    s = sys.stdin.readline().strip()
    if people.__contains__(s):
        print("What is the new tel-number?")
        contact[s].n = sys.stdin.readline().strip()
        print("What is the new email?");
        contact[s].e = sys.stdin.readline().strip()
        print("Updated Contact " + s + "." + "The new contact information is : " + " Name: " + contact[s].p + " Tel-Number: " +
             contact[s].n + " Email: " + contact[s].e)
    else:
        print("This contact does not exist.")

def search():
    print("Search Contact ========>");
    print("Which contact do you want to search?")
    s = sys.stdin.readline().strip()
    if people.__contains__(s):
        print("The contact information is : " + " Name: " + contact[s].p + " Tel-Number: " + contact[s].n + " Email: " +
              contact[s].e)
    else:
        print("This contact does not exist.")

def listAction():
    print("Contact List" + "\n" + "++++++++++++++++++++++++++++++++++++++++++++++")
    print(contact)
    print("++++++++++++++++++++++++++++++++++++++++++++++")

def save():
    with open('contact.txt', 'w') as fp:
        fp.seek(0)
        fp.truncate()
        for i in range(len(people)):
            fp.write(contact[people[i]].p + ' ' + contact[people[i]].n + ' ' + contact[people[i]].e)
            i = i + 1
    print("Changes saved.")

class Contact:
    def __init__(self, p, n, e):
        self.p = p
        self.n = n
        self.e = e

    def __str__(self):
        return "Name : " + self.p + ", Tel-Number : " + self.n + ", Email : " + self.e + "\n"

    def __repr__(self):
        return str(self)


print("Contact List" + "\n" + "++++++++++++++++++++++++++++++++++++++++++++++")
load()
print("++++++++++++++++++++++++++++++++++++++++++++++")
print("What do you want to do?"+ "\n" + "1: Add" + "\n" + "2: Remove" + "\n" + "3: Update" + "\n" + "4: Search" + "\n" + "5: List" + "\n" + "6: Save" + "\n" + "7: Quit")
action = sys.stdin.readline().strip()
while action != '':
    if action == 'add' or action == 'Add' or action == '1':
        add()
    elif action == 'remove'or action == 'Remove' or action == '2':
        print("Remove Contact ========>")
        print("Remove which people?")
        print(people)
        p = sys.stdin.readline().strip()
        remove(p)
    elif action == 'update'or action == 'Update' or action == '3':
        update()
    elif action == 'search'or action == 'Search' or action == '4':
        search()
    elif action == 'list'or action == 'List' or action == '5':
        listAction()
    elif action == 'save'or action == 'Save' or action == '6':
        save()
    elif action == 'quit'or action == 'Quit' or action == '7':
        save()
        print("Bye bye !")
        break
    print("What do you want to do?")
    action = sys.stdin.readline().strip()

print(contact)

