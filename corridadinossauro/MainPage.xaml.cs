namespace corridadinossauro;

public partial class MainPage : ContentPage
{

	bool estaMorto=false;
	bool estaPulando=false;
	const int tempoEntreFrames=25;
	int velocidade1=0;
	int velocidade2=0;
	int velocidade3=0;
	int velocidade=0;
	int larguraJanela=0;
	int alturaJanela=0;


    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
		CorrigeTamanhoCenario(width,height);
		CalculaVelocidade(width);
    }

	void CalculaVelocidade(double width)
	{
		velocidade1=(int)(width*0.001);
		velocidade2=(int)(width*0.004);
		velocidade3=(int)(width*0.008);
		velocidade=(int)(width*0.01);
	}

	void CorrigeTamanhoCenario(double width,double height)
	{
		foreach(var A in HSLayer1.Children)
		(A as Image).WidthRequest=width;
		foreach(var A in HSLayer2.Children)
		(A as Image ).WidthRequest=width;
		foreach(var A in HSLayer3.Children)
		(A as Image).WidthRequest=width;
		foreach(var A in HSLayerChao.Children)
		(A as Image).WidthRequest=width;

		HSLayer1.WidthRequest=width*1.5;
		HSLayer2.WidthRequest=width*1.5;
		HSLayer3.WidthRequest=width*1.5;
		HSLayerChao.WidthRequest=width*1.5;

	}

    void Gerencia Cenarios()
{
	MoveCenario();
	GerenciaCenario (HSLayer1);
	GerenciaCenario (HSLayer2);
	GerenciaCenario (HSLayer3);
	GerenciaCenario (HSLayer4);
}

void Move Cenario()
{
	HSLayer1.TranslationX-=velocidade1;
	HSLayer1.TranslationX-=velocidade2;
	HSLayer1.TranslationX-=velocidade3;
	ASLayerChao.TranslationX-=velocidade;

}

void Gerencia Cenario(HorizontalStackLayout HSL)
{
	var view = (HSL.Children.First()as Image);
	if(view.WidthRequest+HSL.TranslationX<0)
	{
		HSL.Children.Remove(view);
		HSL.Children.Add(view);
		HSL.TranslationX=view.TranslationX;
	}
}

async Task Desenha()
{
	while(!estaMorto)
	{
		GerenciaCenarios()
		await Task.Delay(tempoEntreFrames);
	}
}
	public MainPage()
	{
		InitializeComponent();
	}

public class Animacao
{
	protected List<String> animacao1= new List<string>();
	protected List<String> animacao2= new List<string>();
	protected List<String> animacao3= new List<string>();
	protected bool loop=true;
	protected int animacaoAtiva=1;
	bool parado=true;
	int frameAtual=1;
	protected Image compImagem;
	public Animacao(Image a )
	{
		compImagem=a;
	}

	public void Stop()
	{
		parado=true;
	}
	public void Play()
	{
		parado=false;
	}
	public void SetAnimacaoAtiva(int A)
	{
		animacaoAtiva=A;
	}

}

public void Desenha()
{
	if(parado)
		return;
		String nomeArquivo="";
		int tamanhoAnimacao=0;
		if(AnimacaoAtiva==1)
		{
			nomeArquivo= Animacao1[frameAtual];
			tamanhoAnimacao=Animacao1.Count;
		}
		else if (AnimacaoAtiva==2)
		{
			nomeArquivo=Animacao2{frameAtual};
			tamanhoAnimacao=Animacao2.Count;
		}
		else if (AnimacaoAtiva==3)
		{
			nomeArquivo=Animacao3{frameAtual};
			tamanhoAnimacao=Animacao3.Count;
		}
		compImagem.Source=ImageSource.FromFile(nomeArquivo);
		frameAtual++;
		if(framAtual>=tamanhoAnimacao)
		{
			if(loop)
				frameAtual=0;
				else{
					parado=true;
					QuandoParar();
				}
		}
}
public virtual void QuandoParar()
{
	
}

}


