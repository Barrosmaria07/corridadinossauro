using System.Linq.Expressions;
namespace corridadinossauro;
public delegate void Callback();
 public class Player: Animacao
 {


    public Player (Image a ):base(a)

 {
 for (int i=1; i<=12;++i)
    Animacao1.Add($"dog{i.ToString("D2")}.png");
 // for (int i=1; i<=12;++i)
  // Animacao1.Add($"dog{i.ToString("D2")}.png");
 SetAnimacaoAtiva(1);
 
 }
 public void Die()
   {
    loop=false;
    SetAnimacaoAtiva(2);
   }

   public void Run()
   {
    loop=true;
    SetAnimacaoAtiva(1);
    Play();
   }

     public void MoveY(int s)
    {
        imageView.TranslationY +=s;
    }

    public double GetY()
    {
        return imageView.TranslationY;
    }
    
    public void SetY(double a)
    {
        imageView.TranslationY = a;
    }
    
 }