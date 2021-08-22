# public-repository
repositoryをpublic状態にしてActionなどの動作を確認するためのRepository

【注意！】現状の各branchの状態について

master - C#用のセッティングが完了してないためbuildでエラーになる。

（本来あるべき姿（masterは本番環境へリリース可能な状態のもののみ配置する）とは違う状態である点に注意）

develop - 複数のC#codeの中にerrorとなるものが内包されているためbuildがエラーとなる。

develop2- build確認済でエラーとならない構成。

■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
### `master branch`
.slnファイルがなく、更にsanmokunarabe.csprojでもcompile対象への

linkを記載していないためCodeScanが通らない。

Develop2をマージする事でERRORがなくなった状態となる。

（本来この形はdeploy可能な状態を維持できていないため望ましくない）

■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

`CodeScanning格納 BuildはAutoBuildを利用`

◆GitHubAction CodeScan（.Github/workflow）

https://github.com/operation-check/testrep/tree/master/.github/workflows

`VisualStudio管理用ファイルが入っているフォルダ`

◆VisualStudio用フォルダ（.vs）

https://github.com/operation-check/testrep/tree/master/.vs

------------------------------------------

`Code 以下２つのフォルダ内にプログラムコードと実行ファイルを格納済。`

`hello worldを表示するだけのもの。`

・test00：HelloWorld(test00)

https://github.com/operation-check/testrep/tree/master/test00

------------------------------------------

`コンソールにて三目並べができる「らしい」が起動は一応非推奨。
あくまでも「コードのサンプル」としてだけのもの。`

・test01：三目並べ(sanmokunarabe)

https://github.com/operation-check/testrep/tree/master/sanmokunarabe


