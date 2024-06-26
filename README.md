
### Visual Studioで既存プロジェクトを開く

1. **Visual Studioの起動**:
   - コンピュータにVisual Studioがインストールされていることを確認してください。インストールされていない場合は、[Visual Studioの公式サイト](https://visualstudio.microsoft.com/)からダウンロードしてインストールします。

2. **プロジェクトの取得**:
   - プロジェクトのファイル（通常は`.sln`ファイルと関連するフォルダーとファイル）を共有方法（例: GitHub、Zipファイル、ファイル共有サービス）で受け取ります。

3. **プロジェクトの開く**:
   - Visual Studioを開きます。
   - 「ファイル」メニューから「開く」>「プロジェクト/ソリューション」を選択します。
   - ダウンロードまたはコピーしたプロジェクトフォルダ内の`.sln`ファイル（ソリューションファイル）を選択して開きます。

### プロジェクトの実行

1. **デバッグなしで実行**:
   - 「デバッグ」メニューから「デバッグなしで開始」（Ctrl + F5）を選択してアプリケーションを実行します。

2. **デバッグモードで実行**:
   - 「デバッグ」メニューから「デバッグ開始」（F5）を選択してデバッグモードでアプリケーションを実行します。これにより、ブレークポイントでコードの実行を一時停止し、変数の内容を調べることができます。


# calc_test

## 電卓アプリケーション「calc_test」の概要

`calc_test`は、基本的な数学的演算を提供するUWP（Universal Windows Platform）アプリケーションです。このアプリケーションは、四則演算（加算、減算、乗算、除算）およびメモリ操作をサポートしています。

### 主要な機能

- **基本的な算術演算**: ユーザーが入力した数値に基づいて加算、減算、乗算、除算を行います。
- **メモリ操作**: 計算結果をメモリに保存し、必要に応じて呼び出します。
- **クリア機能**: 入力または全てのデータをクリアします。

### クラスとメソッドの説明

#### プロパティ

- `private string input`: ユーザーからの入力を保持します。
- `private string operand1`: 最初のオペランドを保持します。
- `private string operand2`: 二番目のオペランドを保持します。
- `private char operation`: 現在選択されている演算子を保持します。
- `private double result`: 計算結果を保持します。
- `private double memory`: メモリに保存された数値を保持します。

#### コンストラクタ

- `public MainPage()`: コンポーネントを初期化します。

#### メソッド

- `private void Button_Click(object sender, RoutedEventArgs e)`: ボタンがクリックされた時に呼び出され、押されたボタンに応じて適切な操作を行います。
- `private void PerformCalculation()`: 選択された演算子に基づいて計算を実行します。
- `private void ClearAll()`: 全ての入力と計算結果をクリアします。
- `private void HandleNumberInput(string pressed)`: 数字ボタンが押された場合の入力処理を行います。
- `private void UpdateCalcResult(double result)`: 計算結果を画面に表示します。

### 使用方法

1. 数字ボタンをクリックして数値を入力します。
2. 演算子ボタン（+, -, ×, ÷）をクリックして演算子を選択します。
3. 次の数値を入力し、`=` ボタンを押して結果を表示します。
4. `C` ボタンで最後の入力をクリア、`AC` ボタンで全てをクリアします。
5. `M+` と `M-` ボタンでメモリに加算または減算、`MRC` でメモリから数値を呼び出します。

