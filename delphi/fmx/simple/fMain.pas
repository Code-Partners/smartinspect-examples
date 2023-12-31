unit fMain;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Graphics, FMX.Dialogs,
  FMX.Controls.Presentation, FMX.StdCtrls;

type
  TForm4 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form4: TForm4;

implementation
uses
  SmartInspect.FMX.SiAuto, SmartInspect.FMX;

{$R *.fmx}

procedure TForm4.Button1Click(Sender: TObject);
begin
  SiMain.LogMessage('Hello from FMX');
end;

end.
