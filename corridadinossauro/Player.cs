using System.Linq.Expressions;

public delegate void Callback();
 public class Player: Animacao
 {
    public Player (Image a ):base(a)

 {
 for (int i=1; i<=12;++i)
    animacao1.Add($"dog{i.ToString("D2")}.png");
  //  for (int i=1; i<=12;++i)
   // animacao1.Add($"dog{i.ToString("D2")}.png");//
 SetAnimacaoAtiva(1)
 
 }
 public void Die()
   {
    Loop=false;
    SetAnimacaoAtiva(2);
   }

   public void Run()
   {
    Loop=true;
    SetAnimacaoAtiva(1);
    Player();
   }
 }