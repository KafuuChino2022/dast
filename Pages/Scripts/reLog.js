/**
 * 返回登录确认功能
 * 在所有页面中自动为返回登录链接添加确认对话框
 */
document.addEventListener('DOMContentLoaded', () => {
    // 查找所有返回登录链接（支持多种选择器）
    const logoutLinks = document.querySelectorAll('[href*="../LogPages/log"], #logout-link, .logout-link');
    
    logoutLinks.forEach(link => {
      link.addEventListener('click', async function(e) {
        e.preventDefault();
        
        const confirmed = await ConfirmDialog.show({
          message: '您确定要返回登录界面吗？当前未保存的进度将丢失。',
          confirmText: '确定返回',
          cancelText: '取消'
        });
        
        if (confirmed) {
          window.location.href = this.getAttribute('href');
        }
      });
    });
  });