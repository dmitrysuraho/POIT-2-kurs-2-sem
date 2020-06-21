package Store;

public class BuildingStore {
    public String item;
    public int price;
    public int quantity;

    public BuildingStore(String Item, int Price, int Quantity) {
        item = Item;
        price = Price;
        quantity = Quantity;
    }

    @Override
    public String toString() {
        return item + " " + price + " " + quantity + "\n";
    }
}
