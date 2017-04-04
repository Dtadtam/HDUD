import { HDUDWEBAPPPage } from './app.po';

describe('hdud-webapp App', function() {
  let page: HDUDWEBAPPPage;

  beforeEach(() => {
    page = new HDUDWEBAPPPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
