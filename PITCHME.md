## キラキラ・ぴかぴかゲームを
## プログラミング！

デジタルアーツ東京　体験入学

たなかゆう@AmuseOne1

---

## パーティクル
## ↓
## Particles
## ↓
## 粒子

---

### 概要
- <b>光るもの</b>や<b>煙</b>などの形がないものの表現手法
- ゲームの演出の定番

---

### デフォルトのパーティクル

- <i>Assets</i>メニューから<i>Import Package</i> -> <i>ParticleSystems</i>を選択して<i>Import</i>
- <i>Project</i>ビューの<i>Standard Assets</i> -> <i>ParticleSystems</i> -> <i>Prefabs</i>フォルダーを開く
- 中のプレハブをシーンに配置して確認してみよう
- 箱の子供にして、<i>Position</i>を`0`,`0`,`0`にする

---

### アセットストア

- Unityの<i>Window</i> -> <i>Asset Store</i>でアセットストアを開く
- 検索欄に`particle`、価格を`0`円にして、パーティクルを検索
- 気になったプレハブをインポートして、サンプルシーンを開いてみよう
- <b>100MB</b>を超えるパーティクルは時間がかかるので今回は避けよう

---

### おすすめパーティクル

- Particle Collection SKJ 2016_Free samples
- PowerUp particles

---

以下に使うパーティクルを探してみよう

1. ダメージを受けそうな表現
1. 箱が壊れる表現
1. スタート地点っぽい表現
1. ワープできそうな表現
1. プレイヤーが登場する時の表現
- <i>Scaling Mode</i>を<i>Hierarchy</i>にすると、<i>Scale</i>で簡単に大きさ調整ができる

---

## ユニティちゃんの紹介

http://unity-chan.com/

---

## Post Processing Stack

---

### 概要
- Post Processingとは、**後処理**という意味
- 一度描画した画面に対して、光を強調したり、輪郭を描いたり、ノイズを載せたりといった演出を描き込む
- 最近のゲーム機では必須の技術

---

### 演習

---

#### 読み込み

- アセットストアで`post`を検索して、`Post Processing Stack`をインポート
- 何か表示されたら"I Made a Backup, Go Ahead!"をクリック
- Importボタンをクリック

---

#### 初期設定

- Hierarchyビューから、Main Cameraを選択
- Inspectorビューから、Add Componentをクリックして、Effects -> Post-Processing Behaviourを選択
- ProjectビューのCreateをクリックして、Post-Processing Profileを選択して、[Enter]キーで名前を確定
- Hierarchyビューから、Main Cameraを選択
- Projectビューから、New Post-Processing Profileをドラッグして、InspectorビューのProfile欄にドロップ

---

#### 各種設定

- Projectビューから、New Post-Processing Profileを選択
- Inspectorビューに各種設定が表示されるので、チェックを入れて、パラメーターを変更して観察してみよう

---

## ステージ作成

---


---

## ゲーム画面を仕上げよう

- Main Cameraの背景色を調整する
