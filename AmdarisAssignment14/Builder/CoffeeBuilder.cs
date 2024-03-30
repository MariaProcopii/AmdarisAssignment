using AmdarisAssignment14.Model;

namespace AmdarisAssignment14.Builder;

public class CoffeeBuilder
{
    private Drink _drink = new Drink();

    public void Reset()
    {
        _drink = new Drink();
    }

    public CoffeeBuilder AddBlackCoffee()
    {
        _drink.AddBlackCoffee(new BlackCoffee());
        return this;
    }

    public CoffeeBuilder AddSugar()
    {
        _drink.AddSugar(new Sugar());
        return this;
    }

    public CoffeeBuilder AddMilk(MilkType milkType)
    {
        switch (milkType)
        {
            case MilkType.Regular:
            {
                _drink.AddMilk(new RegularMilk());
                return this;
            }
            case MilkType.Soy:
            {
                _drink.AddMilk(new SoyMilk());
                return this;
            }
            case MilkType.Oat:
            {
                _drink.AddMilk(new OatMilk());
                return this;
            }
            default:
                throw new ArgumentException("Invalid Milk Type");
        }
    }

    public Drink Build()
    {
        return _drink;
    }
}