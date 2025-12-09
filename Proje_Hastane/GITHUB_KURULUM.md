# GitHub Bağlantı Adımları

## 1. Git Kurulumu
Eğer Git yüklü değilse: https://git-scm.com/download/win

## 2. GitHub'da Repository Oluştur
- GitHub.com'a git
- "New repository" butonuna tıkla
- Repository adını gir (örn: Proje_Hastane)
- Public/Private seç
- "Create repository" butonuna tıkla

## 3. Projeyi Git ile Bağla

PowerShell'i proje klasöründe aç ve şu komutları sırayla çalıştır:

```powershell
# Git repository başlat
git init

# Tüm dosyaları ekle
git add .

# İlk commit
git commit -m "İlk commit - Hastane Projesi"

# GitHub repository URL'ini ekle (kendi URL'ini kullan)
git remote add origin https://github.com/KULLANICI_ADIN/REPO_ADI.git

# Ana branch'i main olarak ayarla
git branch -M main

# GitHub'a gönder
git push -u origin main
```

## 4. Otomatik Senkronizasyon İçin

Her değişiklikten sonra şu komutları çalıştır:

```powershell
git add .
git commit -m "Değişiklik açıklaması"
git push
```

## 5. Başka Bilgisayarda Kullanmak İçin

```powershell
git clone https://github.com/KULLANICI_ADIN/REPO_ADI.git
cd REPO_ADI
```

## 6. GitHub Kimlik Doğrulama (ÖNEMLİ!)

GitHub artık şifre ile push kabul etmiyor. **Personal Access Token (PAT)** kullanman gerekiyor:

### Token Oluşturma:
1. GitHub.com'a git ve giriş yap
2. Sağ üstte profil fotoğrafına tıkla → **Settings**
3. Sol menüden **Developer settings**
4. **Personal access tokens** → **Tokens (classic)**
5. **Generate new token** → **Generate new token (classic)**
6. **Note**: Token için bir isim ver (örn: "Proje_Hastane")
7. **Expiration**: Süre seç (90 gün veya No expiration)
8. **Select scopes**: En azından **repo** seçeneğini işaretle
9. **Generate token** butonuna tıkla
10. **ÖNEMLİ**: Token'ı kopyala (bir daha gösterilmeyecek!)

### Token ile Push Yapma:

```powershell
# Push yaparken:
git push -u origin main

# Username: GitHub kullanıcı adın
# Password: Oluşturduğun TOKEN'ı yapıştır (şifre değil!)
```

### Token'ı Kaydetme (Her seferinde girmemek için):

**Windows için:**
```powershell
# Git Credential Manager'ı kullan (otomatik kaydeder)
git config --global credential.helper wincred

# Veya manuel kaydet:
git config --global user.name "KULLANICI_ADIN"
git config --global user.email "EMAIL_ADRESIN"
```

**Not:** İlk push'tan sonra Windows Credential Manager token'ı kaydeder, sonraki push'larda otomatik kullanır.

