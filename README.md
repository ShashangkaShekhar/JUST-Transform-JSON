# JUST-Transform-JSON

NUGET
https://www.nuget.org/packages/JUST.net/

JUST - JSON Under Simple Transformation
https://www.codeproject.com/Articles/1187172/JUST-JSON-Under-Simple-Transformation

C# JUST Library for JSON to JSON transformation
https://social.technet.microsoft.com/wiki/contents/articles/37933.c-just-library-for-json-to-json-transformation.aspx

JUST.net
https://github.com/WorkMaze/JUST.net


Consider the input:
{
  "menu": {
    "popup": {
      "menuitem": [{
          "value": "Open",
          "onclick": "OpenDoc()"
        }, {
          "value": "Close",
          "onclick": "CloseDoc()"
        }
      ],
	  "submenuitem": "CloseSession()"
    }
  }
}

Transformer:
{
  "result": {
    "Open": "#valueof($.menu.popup.menuitem[?(@.value=='Open')].onclick)",
    "Close": "#valueof($.menu.popup.menuitem[?(@.value=='Close')].onclick)"
  }
}

Output:
{
  "result": {
    "Open": "OpenDoc()",
	"Close": "CloseDoc()"
  }
}
