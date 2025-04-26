/**
 * 确认对话框模块
 * 使用方式：
 * ConfirmDialog.show({
 *   message: '确认消息',
 *   onConfirm: () => { /* 确认回调 * / },
 *   onCancel: () => { /* 取消回调 * / },
 *   confirmText: '确定',
 *   cancelText: '取消'
 * });
 */
class ConfirmDialog {
    static init() {
      // 创建对话框DOM
      const dialogHTML = `
        <div class="confirm-dialog" id="confirm-dialog" style="display:none;">
          <div class="confirm-dialog-content">
            <p class="confirm-message"></p>
            <div class="confirm-buttons">
              <button class="confirm-btn cancel-btn"></button>
              <button class="confirm-btn ok-btn"></button>
            </div>
          </div>
        </div>
      `;
      
      document.body.insertAdjacentHTML('beforeend', dialogHTML);
      
      // 获取元素引用
      this.dialog = document.getElementById('confirm-dialog');
      this.messageEl = this.dialog.querySelector('.confirm-message');
      this.okBtn = this.dialog.querySelector('.ok-btn');
      this.cancelBtn = this.dialog.querySelector('.cancel-btn');
      
      // 绑定事件
      this.okBtn.addEventListener('click', () => this._handleConfirm());
      this.cancelBtn.addEventListener('click', () => this._handleCancel());
    }
    
    static show(options) {
      this.messageEl.textContent = options.message || '确定要执行此操作吗？';
      this.okBtn.textContent = options.confirmText || '确定';
      this.cancelBtn.textContent = options.cancelText || '取消';
      
      this._resolve = null;
      this._options = options;
      this.dialog.style.display = 'flex';
      
      return new Promise((resolve) => {
        this._resolve = resolve;
      });
    }
    
    static _handleConfirm() {
      this.dialog.style.display = 'none';
      if (this._options.onConfirm) this._options.onConfirm();
      if (this._resolve) this._resolve(true);
    }
    
    static _handleCancel() {
      this.dialog.style.display = 'none';
      if (this._options.onCancel) this._options.onCancel();
      if (this._resolve) this._resolve(false);
    }
  }
  
  // 初始化对话框
  document.addEventListener('DOMContentLoaded', () => ConfirmDialog.init());