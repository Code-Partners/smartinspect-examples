program SimpleFMXSample;

uses
  System.StartUpCopy,
  FMX.Forms,
  fMain in 'fMain.pas' {Form4},
  SmartInspect.FMX.SiAuto;

{$R *.res}

begin
//  Si.Connections := 'tcp()';
  Si.Enabled := True;
  SiMain.EnterProcess('SimpleFMXSample');
  try
    Application.Initialize;
    Application.CreateForm(TForm4, Form4);
    Application.Run;
  finally
    SiMain.LeaveProcess('SimpleFMXSample');
  end;
end.
